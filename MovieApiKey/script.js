const API_KEY = "39b1c15b3a6b4ab091cc0e369a324028";

const API_URL = "https://newsapi.org/v2/top-headlines";


const newsContainer =
    document.getElementById("newsContainer");

const loading =
    document.getElementById("loading");

const error =
    document.getElementById("error");


// Load News
async function loadNews(category = "general") {

    loading.style.display = "block";

    error.innerText = "";

    newsContainer.innerHTML = "";


    try {

        const url =
            `${API_URL}?country=us&category=${category}&pageSize=20&apiKey=${API_KEY}`;


        const response = await fetch(url);

        const data = await response.json();


        if (data.status !== "ok") {

            throw new Error(
                data.message || "Unable to load news."
            );

        }


        displayNews(data.articles);

    }

    catch (err) {

        error.innerText =
            "Something went wrong: " + err.message;

    }

    finally {

        loading.style.display = "none";

    }
}



// Display News Cards
function displayNews(articles) {

    if (!articles || articles.length === 0) {

        newsContainer.innerHTML =
            "<p>No news found.</p>";

        return;
    }


    articles.forEach(article => {

        const card =
            document.createElement("div");

        card.className = "news-card";


        const image =
            article.urlToImage ||
            "https://via.placeholder.com/600x400?text=No+Image";


        const description =
            article.description ||
            "No description available.";


        const title =
            article.title ||
            "No title available.";


        const source =
            article.source?.name ||
            "Unknown Source";


        card.innerHTML = `

            <img
                src="${image}"
                alt="News Image"
                onerror="this.src='https://via.placeholder.com/600x400?text=No+Image'"
            >

            <div class="news-content">

                <div class="source">
                    ${source}
                </div>

                <h2>
                    ${title}
                </h2>

                <p>
                    ${description}
                </p>

                <a
                    href="${article.url}"
                    target="_blank"
                    class="read-more"
                >
                    Read More
                </a>

            </div>
        `;


        newsContainer.appendChild(card);

    });
}



// Search News
async function searchNews() {

    const searchInput =
        document.getElementById("searchInput");

    const keyword =
        searchInput.value.trim();


    if (!keyword) {

        alert("Please enter a news topic.");

        return;
    }


    loading.style.display = "block";

    error.innerText = "";

    newsContainer.innerHTML = "";


    try {

        const url =
            `https://newsapi.org/v2/everything?q=${encodeURIComponent(keyword)}&language=en&sortBy=publishedAt&pageSize=20&apiKey=${API_KEY}`;


        const response =
            await fetch(url);


        const data =
            await response.json();


        if (data.status !== "ok") {

            throw new Error(
                data.message || "Search failed."
            );

        }


        displayNews(data.articles);

    }

    catch (err) {

        error.innerText =
            "Search error: " + err.message;

    }

    finally {

        loading.style.display = "none";

    }
}



// Press Enter to Search
document
    .getElementById("searchInput")
    .addEventListener("keypress", function(event) {

        if (event.key === "Enter") {

            searchNews();

        }

    });



// Load General News when page opens
loadNews();