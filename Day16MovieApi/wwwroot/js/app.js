const apiUrl="/api/movies";
async function loadMovies(){
const response=await fetch(apiUrl);
const movies=await response.json();
const container=document.getElementById("movieContainer");
container.innerHTML="";
movies.forEach(movie=>{
container.innerHTML+=`
<div class="movie-card">
<img src="${movie.posterUrl}">
<h3>${movie.title}</h3>
<p>Genre: ${movie.genre}</p>
<p>Year: ${movie.releaseYear}</p>
<p>Rating: ⭐ ${movie.rating}</p>
<a href="movie-details.html?id=${movie.id}">
<button>Details</button>
</a>
<a href="edit-movie.html?id=${movie.id}">
<button>Edit</button>
</a>
<button onclick="deleteMovie('${movie.id}')">
Delete
</button>
</div>
`;
});
}
async function deleteMovie(id){
let confirmDelete=confirm("Delete this movie?");
if(!confirmDelete)
return;
await fetch(`${apiUrl}/${id}`,{
method:"DELETE"
});
loadMovies();
}
loadMovies();