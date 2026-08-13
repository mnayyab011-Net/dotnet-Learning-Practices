const API_BASE_URL = "http://localhost:5095/api";
async function loadPosts() {
    const container = document.getElementById("postsContainer");
    if (!container) {
        return;
    }
    container.innerHTML = `
        <div class="loading">
            <div class="spinner"></div>
            <p>Loading articles...</p>
        </div>
    `;
    try {
        const response = await fetch(`${API_BASE_URL}/Post`);
        if (!response.ok) {
            throw new Error(`API Error: ${response.status}`);
        }
        const posts = await response.json();
        if (!posts || posts.length === 0) {
            container.innerHTML = `
                <div class="empty-state">
                    <div class="empty-icon">✦</div>
                    <h3>No articles yet</h3>
                    <p>No posts are available in the database.</p>
                </div>
            `;
            return;
        }
        container.innerHTML = posts.map((post, index) => `
            <article class="post-card">
                <div class="card-number">
                    ${String(index + 1).padStart(2, "0")}
                </div>
                <span class="post-category">
                    ${escapeHtml(post.categoryName || "ARTICLE")}
                </span>
                <h3>
                    ${escapeHtml(post.title || "Untitled Post")}
                </h3>
                <p>
                    ${escapeHtml(
                        post.content || "No content available."
                    )}
                </p>
                <div class="post-meta">
                    <span>MyBlog</span>
                    <span>↗</span>
                </div>
            </article>
        `).join("");
    } catch (error) {
        console.error("Post loading error:", error);
        container.innerHTML = `
            <div class="empty-state error">
                <div class="empty-icon">!</div>
                <h3>Unable to load articles</h3>
              <p>
                    Please make sure your Blog API is running.
                </p>
                <button
                    class="refresh-btn"
                    onclick="loadPosts()">
                    Try Again
                </button>
            </div>
        `;
    }
}
async function loadCategories() {
    const container =
        document.getElementById("categoriesContainer");
    if (!container) {
        return;
    }
    try {
        const response =
            await fetch(`${API_BASE_URL}/Category`);
        if (!response.ok) {
            throw new Error(`API Error: ${response.status}`);
        }
        const categories =
            await response.json();
        if (!categories || categories.length === 0) {
            container.innerHTML = `
                <div class="category-card">
                    <h3>No Categories</h3>
                    <p>No categories available.</p>
                </div>
            `;
            return;
        }
        container.innerHTML = categories.map(category => `
            <div class="category-card">
                <h3>
                    ${escapeHtml(category.name || "Category")}
                </h3>
                <p>
                    Explore ${escapeHtml(category.name || "this")}
                    posts.
                </p>
            </div>
        `).join("");
    } catch (error) {
        console.error("Category loading error:", error);
        container.innerHTML = `
            <div class="category-card">
                <h3>Unable to load categories</h3>
                <p>Please try again later.</p>
            </div>
        `;
    }
}
function scrollToPosts() {
    const posts =
        document.getElementById("posts");
    if (posts) {
        posts.scrollIntoView({
            behavior: "smooth"
        });
    }
}
function escapeHtml(value) {
    const div =
        document.createElement("div");
    div.textContent = value ?? "";
    return div.innerHTML;
}
loadPosts();
loadCategories();