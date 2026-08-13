const API_URL = "http://localhost:5095/api/Post";
const DEFAULT_CATEGORY_ID = 1;
document.addEventListener("DOMContentLoaded", function () {
    loadPosts();
    const form = document.getElementById("postForm");
    const imageUrlInput =
        document.getElementById("imageUrl");
    if (imageUrlInput) {
        imageUrlInput.addEventListener(
            "input",
            function () {
                showImagePreview(
                    this.value.trim()
                );

            }
        );
    }
    if (form) {
        form.addEventListener(
            "submit",
            async function (event) {
                event.preventDefault();
                const id =
                    document.getElementById("postId").value.trim();
                const title =
                    document.getElementById("title").value.trim();
                const content =
                    document.getElementById("content").value.trim();
                const imageUrl =
                    document.getElementById("imageUrl").value.trim();
                const token = getToken();
                if (!token) {
                    alert("Please login first.");
                    window.location.href =
                        "login.html";
                    return;
                }
                if (!title) {
                    alert("Please enter a title.");
                    return;
                }
                if (title.length < 50) {
                    alert(
                        `Title must be at least 50 characters.\n\nCurrent length: ${title.length}`
                    );
                    return;
                }
                if (!content) {
                    alert("Please enter post content.");
                    return;
                }
                if (imageUrl) {
                    try {
                        new URL(imageUrl);
                    } catch {
                        alert(
                            "Please enter a valid image URL."
                        );
                        return;
                    }
                }
                const body = {
                    title: title,
                    content: content,
                    imageUrl: imageUrl || null,
                    categoryId: DEFAULT_CATEGORY_ID
                };
                console.log(
                    "Sending Post:",
                    body
                );
                const isEdit = id !== "";
                try {
                    const response = await fetch(
                        isEdit
                            ? `${API_URL}/${id}`
                            : API_URL,
                        {
                            method:
                                isEdit
                                    ? "PUT"
                                    : "POST",
                            headers: {
                                "Content-Type":
                                    "application/json",
                                "Authorization":
                                    "Bearer " + token
                            },
                            body:
                                JSON.stringify(body)
                        }
                    );
                    if (response.status === 401) {
                        localStorage.removeItem(
                            "token"
                        );
                        alert(
                            "Session expired. Please login again."
                        );
                        window.location.href =
                            "login.html";
                        return;
                    }
                    const responseText =
                        await response.text();
                    console.log(
                        "API Status:",
                        response.status
                    );
                    console.log(
                        "API Response:",
                        responseText
                    );
                    if (!response.ok) {
                        let errorMessage =
                            "Unable to save post.";
                        try {
                            const errorData =
                                JSON.parse(
                                    responseText
                                );
                            if (
                                errorData.errors
                            ) {
                                const errors = [];
                                Object.keys(
                                    errorData.errors
                                ).forEach(
                                    key => {
                                        errorData
                                            .errors[key]
                                            .forEach(
                                                msg => {
                                                    errors.push(
                                                        `${key}: ${msg}`
                                                    );
                                                }
                                            );
                                    }
                                );
                                if (errors.length > 0) {
                                    errorMessage =
                                        errors.join(
                                            "\n"
                                        );
                                }
                            }
                            else if (
                                errorData.title
                            ) {
                                errorMessage =
                                    errorData.title;
                            }
                            else if (
                                errorData.message
                            ) {
                                errorMessage =
                                    errorData.message;
                            }
                        } catch {
                            if (responseText) {
                                errorMessage =
                                    responseText;
                            }
                        }
                        console.error(
                            "SAVE POST ERROR:",
                            errorMessage
                        );
                        alert(
                            "API Error:\n\n" +
                            errorMessage
                        );
                        return;
                    }
                    closeModal();
                    showMessage(
                        isEdit
                            ? "Post updated successfully!"
                            : "Post created successfully!",
                        true
                    );
                    await loadPosts();
                }
                catch (error) {
                    console.error(
                        "FETCH ERROR:",
                        error
                    );
                    showMessage(
                        "Unable to connect to Blog API.",
                        false
                    );
                }
            }
        );
    }
});
function getToken() {
    return localStorage.getItem(
        "token"
    );
}
async function loadPosts() {
    const container =
        document.getElementById(
            "postsContainer"
        );
    const totalPosts =
        document.getElementById(
            "totalPosts"
        );
    const apiStatus =
        document.getElementById(
            "apiStatus"
        );
    if (!container) {
        return;
    }
    const token = getToken();
    if (!token) {
        container.innerHTML = `
            <div class="empty">
                <h3>Login Required</h3>
                <p>
                    Please login first.
                </p>
            </div>
        `;
        if (apiStatus) {
     apiStatus.innerText =
                "No Token";
        }
        return;
    }
    container.innerHTML = `
<div class="loading">
            Loading posts...
        </div>
    `;
    if (apiStatus) {
        apiStatus.innerText =
            "Checking...";
    }
    try {
   const response =
            await fetch(
                API_URL,
                {
                    method: "GET",
                    headers: {
                        "Authorization":
                            "Bearer " + token
                    }
                }
            );
        if (response.status === 401) {
            localStorage.removeItem(
                "token"
            );
            window.location.href =
                "login.html";
            return;
        }
        if (!response.ok) {
            throw new Error(
                "Unable to load posts"
            );
        }
        const posts =
            await response.json();
        if (apiStatus) {
            apiStatus.innerText =
                "Online";
        }
        if (totalPosts) {
            totalPosts.innerText =
                posts.length;
        }
        displayPosts(posts);
    }
    catch (error) {
        console.error(error);
        if (apiStatus) {
            apiStatus.innerText =
                "Offline";
        }
        container.innerHTML = `
            <div class="empty">
                <h3>
                    Unable to load posts
                </h3>
                <p>
                    Please make sure your Blog API is running.
                </p>
                <button
                    class="refresh-btn"
                    onclick="loadPosts()">
                    ↻ Try Again
                </button>
            </div>
        `;
    }
}
function displayPosts(posts) {
    const container =
        document.getElementById(
            "postsContainer"
        );

    if (!posts || posts.length === 0) {
        container.innerHTML = `
            <div class="empty">
                <h3>
                    No Posts Found
                </h3>
                <p>
                    Create your first blog post.
                </p>
            </div>
        `;
        return;
    }
    container.innerHTML = posts.map(
        post => `
        <div class="post-card">
            ${
                post.imageUrl
                    ? `
                    <div class="post-image">
                        <img
                            src="${escapeHtml(post.imageUrl)}"
                            alt="${escapeHtml(
                                post.title ||
                                "Post Image"
                            )}"
                            onerror="
                                this.style.display='none'
                           "
                        >
                    </div>
                    `
                    : ""
            }
            <div class="post-top">
                <span class="post-id">
                    POST #${post.id}
                </span>
                <span class="post-category">
                    ${escapeHtml(
                        post.categoryName ||
                        "ARTICLE"
                    )}
                </span>
            </div>
            <h3>
                ${escapeHtml(
                    post.title ||
                    "Untitled Post"
                )}
            </h3>
            <p>
                ${escapeHtml(
                    post.content ||
                    "No content available."
                )}
            </p>
            <div class="post-meta">
                <span>
                    ${escapeHtml(
                        post.userName ||
                        "MyBlog"
                    )}
                </span>
                <span>
                    ${
                        post.createdAt
                            ? new Date(
                                post.createdAt
                            ).toLocaleDateString()
                            : ""
                    }
                </span>
            </div>
            <div class="post-actions">
                <button
                    class="edit-btn"
                    onclick="editPost(${post.id})">
                    ✏ Edit
                </button>
                <button
                    class="delete-btn"
                    onclick="deletePost(${post.id})">
                    🗑 Delete
                </button>
            </div>
        </div>
        `
    ).join("");
}
function openCreateModal() {
    const modal =
        document.getElementById(
            "postModal"
        );
    if (!modal) {
        return;
    }
    modal.classList.add(
        "show"
    );
    document.getElementById(
        "modalLabel"
    ).innerText =
        "NEW POST";
    document.getElementById(
        "modalTitle"
    ).innerText =
        "Create New Post";
    document.getElementById(
        "saveBtn"
    ).innerText =
        "Create Post";
    document.getElementById(
        "postForm"
    ).reset();
    document.getElementById(
        "postId"
    ).value = "";
    hideImagePreview();
}
function closeModal() {
    const modal =
        document.getElementById(
            "postModal"
        );
    if (modal) {
        modal.classList.remove(
            "show"
        );
    }
    hideImagePreview();
}
async function editPost(id) {
    const token = getToken();
    if (!token) {
        window.location.href =
            "login.html";
        return;
    }
    try {
        const response =
            await fetch(
                `${API_URL}/${id}`,
                {
                    method: "GET",
                    headers: {
                        "Authorization":
                            "Bearer " + token
                    }
                }
            );
        if (response.status === 401) {
            localStorage.removeItem(
                "token"
            );
            window.location.href =
                "login.html";
            return;
        }
        if (!response.ok) {
            throw new Error(
                "Unable to load post"
            );

        }
        const post =
            await response.json();
        document
            .getElementById(
                "postModal"
            )
            .classList.add(
                "show"
            );
        document.getElementById(
            "modalLabel"
        ).innerText =
            "EDIT POST";
        document.getElementById(
            "modalTitle"
        ).innerText =
            "Update Post";
        document.getElementById(
            "saveBtn"
        ).innerText =
            "Update Post";
        document.getElementById(
            "postId"
        ).value =
            post.id;
        document.getElementById(
            "title"
        ).value =
            post.title || "";
        document.getElementById(
            "content"
        ).value =
            post.content || "";
        document.getElementById(
            "imageUrl"
        ).value =
            post.imageUrl || "";
        if (post.imageUrl) {
            showImagePreview(
                post.imageUrl
            );
        }
        else {
            hideImagePreview();
        }
    }
    catch (error) {
        console.error(error);
        alert(
            "Unable to load post."
        );
    }
}
async function deletePost(id) {
    const confirmed =
        confirm(
            "Are you sure you want to delete this post?"
        );
    if (!confirmed) {
        return;
    }
    const token =
        getToken();
    if (!token) {
        window.location.href =
            "login.html";
        return;
    }
    try {
        const response =
            await fetch(
                `${API_URL}/${id}`,
                {
                    method: "DELETE",
                    headers: {
                        "Authorization":
                            "Bearer " + token
                    }
                }
            );
        if (response.status === 401) {
            localStorage.removeItem(
                "token"
            );
            window.location.href =
                "login.html";
            return;
        }
        if (!response.ok) {
            throw new Error(
                "Delete failed"
            );
        }
        showMessage(
            "Post deleted successfully!",
            true
        );
        loadPosts();
    }
    catch (error) {
        console.error(error);
        showMessage(
            "Unable to delete post.",
            false
        );
    }
}
function showImagePreview(url) {
    const preview =
        document.getElementById(
            "imagePreview"
        );
    const image =
        document.getElementById(
            "previewImage"
        );
    if (!preview || !image) {
        return;
    }
    if (!url) {
        hideImagePreview();
        return;
    }
    image.src = url;
    preview.style.display =
        "block";
    image.onerror =
        function () {
            preview.style.display =
                "none";
        };
    image.onload =
        function () {
            preview.style.display =
               "block";
        };
    }
function hideImagePreview() {
    const preview =
        document.getElementById(
            "imagePreview"
        );
    const image =
        document.getElementById(
            "previewImage"
        );
    if (preview) {
      preview.style.display =
            "none";
    }
    if (image) {
        image.src = "";
    }
}
function logout() {
    localStorage.removeItem(
        "token"
    );
    window.location.href =
        "login.html";
}
function showMessage(
    text,
    success
) {
    const message =
        document.getElementById(
            "message"
        );
    if (!message) {
        return;
    }
    message.innerText =
        text;
    message.style.color =
        success
            ? "#16a34a"
            : "#dc2626";
    setTimeout(
        function () {
            message.innerText = "";
        },
        3000
    );
}
function escapeHtml(value) {
    if (
        value === null ||
        value === undefined
    ) {
        return "";
    }
    return String(value)
        .replaceAll(
            "&",
            "&amp;"
        )
        .replaceAll(
            "<",
            "&lt;"
        )
        .replaceAll(
            ">",
            "&gt;"
        )
        .replaceAll(
            '"',
            "&quot;"
        )
        .replaceAll(
            "'",
            "&#039;"
        );
}