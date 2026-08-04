async function loadBooks() {
    let response = await fetch("/api/books");
    let books = await response.json();
    let list = document.getElementById("books");
    list.innerHTML = "";
    books.forEach(book => {
        let item = document.createElement("li");
        item.innerHTML = `
            <strong>📖 ${book.title}</strong><br>
            👤 ${book.author}<br>
            💰 Rs. ${book.price}
        `;
        list.appendChild(item);
    });
}