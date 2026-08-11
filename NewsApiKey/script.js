const API_KEY =
    "9b6d64dca636717ce32678398ac3517a";

const BASE_URL =
    "https://api.themoviedb.org/3";

const IMAGE_URL =
    "https://image.tmdb.org/t/p/w500";


const movieContainer =
    document.getElementById("movieContainer");

const loading =
    document.getElementById("loading");

const error =
    document.getElementById("error");

const sectionTitle =
    document.getElementById("sectionTitle");


// =========================
// API REQUEST
// =========================

async function getMovies(endpoint) {

    loading.style.display = "block";

    error.innerText = "";

    movieContainer.innerHTML = "";


    try {

        const response = await fetch(
            `${BASE_URL}${endpoint}?api_key=${API_KEY}&language=en-US&page=1`
        );


        const data = await response.json();


        if (!response.ok) {

            throw new Error(
                data.status_message ||
                "Failed to load movies."
            );

        }


        displayMovies(data.results);

    }

    catch (err) {

        error.innerText =
            "Error: " + err.message;

    }

    finally {

        loading.style.display = "none";

    }
}


// =========================
// POPULAR MOVIES
// =========================

function loadPopularMovies() {

    sectionTitle.innerText =
        "Popular Movies";

    getMovies("/movie/popular");
}


// =========================
// TOP RATED
// =========================

function loadTopRatedMovies() {

    sectionTitle.innerText =
        "Top Rated Movies";

    getMovies("/movie/top_rated");
}


// =========================
// NOW PLAYING
// =========================

function loadNowPlayingMovies() {

    sectionTitle.innerText =
        "Now Playing";

    getMovies("/movie/now_playing");
}


// =========================
// UPCOMING
// =========================

function loadUpcomingMovies() {

    sectionTitle.innerText =
        "Upcoming Movies";

    getMovies("/movie/upcoming");
}


// =========================
// SEARCH MOVIES
// =========================

async function searchMovies() {

    const searchInput =
        document.getElementById("searchInput");

    const query =
        searchInput.value.trim();


    if (!query) {

        alert("Please enter a movie name.");

        return;
    }


    sectionTitle.innerText =
        `Search Results for "${query}"`;


    loading.style.display = "block";

    error.innerText = "";

    movieContainer.innerHTML = "";


    try {

        const response = await fetch(
            `${BASE_URL}/search/movie?api_key=${API_KEY}&query=${encodeURIComponent(query)}&language=en-US&page=1`
        );


        const data =
            await response.json();


        if (!response.ok) {

            throw new Error(
                data.status_message ||
                "Search failed."
            );

        }


        if (data.results.length === 0) {

            movieContainer.innerHTML =
                "<p>No movies found.</p>";

            return;
        }


        displayMovies(data.results);

    }

    catch (err) {

        error.innerText =
            "Search Error: " + err.message;

    }

    finally {

        loading.style.display = "none";

    }
}


// =========================
// DISPLAY MOVIES
// =========================

function displayMovies(movies) {

    movieContainer.innerHTML = "";


    movies.forEach(movie => {

        const card =
            document.createElement("div");


        card.className =
            "movie-card";


        const poster =
            movie.poster_path
                ? IMAGE_URL + movie.poster_path
                : "https://via.placeholder.com/500x750?text=No+Poster";


        const rating =
            movie.vote_average
                ? movie.vote_average.toFixed(1)
                : "N/A";


        const year =
            movie.release_date
                ? movie.release_date.substring(0, 4)
                : "N/A";


        card.innerHTML = `

            <img
                src="${poster}"
                alt="${movie.title}"
                onerror="
                    this.src='https://via.placeholder.com/500x750?text=No+Poster'
                "
            >

            <div class="movie-info">

                <h3>
                    ${movie.title}
                </h3>

                <div class="movie-meta">

                    <span>
                        ${year}
                    </span>

                    <span class="rating">
                        ⭐ ${rating}
                    </span>

                </div>

            </div>

        `;


        card.addEventListener(
            "click",
            () => showMovieDetails(movie.id)
        );


        movieContainer.appendChild(card);

    });
}


// =========================
// MOVIE DETAILS
// =========================

async function showMovieDetails(movieId) {

    const modal =
        document.getElementById("movieModal");

    const details =
        document.getElementById("movieDetails");


    modal.style.display = "block";


    details.innerHTML =
        "<p>Loading movie details...</p>";


    try {

        const response = await fetch(
            `${BASE_URL}/movie/${movieId}?api_key=${API_KEY}&language=en-US`
        );


        const movie =
            await response.json();


        if (!response.ok) {

            throw new Error(
                movie.status_message ||
                "Could not load details."
            );

        }


        const poster =
            movie.poster_path
                ? IMAGE_URL + movie.poster_path
                : "https://via.placeholder.com/500x750?text=No+Poster";


        const genres =
            movie.genres
                .map(genre => genre.name)
                .join(", ");


        details.innerHTML = `

            <div class="details">

                <img
                    src="${poster}"
                    alt="${movie.title}"
                >

                <div class="details-info">

                    <h2>
                        ${movie.title}
                    </h2>

                    <span>
                        ⭐ Rating:
                        ${movie.vote_average.toFixed(1)}
                    </span>

                    <span>
                        📅 Release Date:
                        ${movie.release_date || "N/A"}
                    </span>

                    <span>
                        🎭 Genres:
                        ${genres || "N/A"}
                    </span>

                    <span>
                        ⏱️ Runtime:
                        ${movie.runtime || "N/A"} minutes
                    </span>

                    <p>
                        ${movie.overview ||
                        "No description available."}
                    </p>

                </div>

            </div>

        `;

    }

    catch (err) {

        details.innerHTML =
            `<p>${err.message}</p>`;

    }
}


// =========================
// CLOSE MODAL
// =========================

function closeModal() {

    document.getElementById(
        "movieModal"
    ).style.display = "none";

}


// Close modal by clicking outside

window.addEventListener(
    "click",
    function(event) {

        const modal =
            document.getElementById(
                "movieModal"
            );


        if (event.target === modal) {

            closeModal();

        }

    }
);


// =========================
// ENTER TO SEARCH
// =========================

document
    .getElementById("searchInput")
    .addEventListener(
        "keypress",
        function(event) {

            if (event.key === "Enter") {

                searchMovies();

            }

        }
    );


// =========================
// INITIAL LOAD
// =========================

loadPopularMovies();