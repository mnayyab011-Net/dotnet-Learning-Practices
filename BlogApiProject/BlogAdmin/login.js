const API_URL = "http://localhost:5095/api/Auth/login";
const loginForm = document.getElementById("loginForm");
const message = document.getElementById("message");
const loginBtn = document.getElementById("loginBtn");
loginForm.addEventListener("submit", async function (event) {
    event.preventDefault();
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value;
    message.textContent = "Logging in...";
    message.className = "message";
    loginBtn.disabled = true;
    try {
        const response = await fetch(API_URL, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                email: email,
                password: password
            })
        });
        const data = await response.json();
        if (!response.ok) {
            message.textContent =
                data.title || "Invalid email or password.";
            message.classList.add("error");
            loginBtn.disabled = false;
            return;
        }
        localStorage.setItem("token", data.token);
        message.textContent = "Login successful!";
        message.classList.add("success");
        setTimeout(() => {
            window.location.href = "index.html";
        }, 500);
    } catch (error) {
        console.error(error);
        message.textContent =
            "Unable to connect to Blog API.";
        message.classList.add("error");
        loginBtn.disabled = false;
    }
});