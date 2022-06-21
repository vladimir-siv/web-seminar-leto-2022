function clearLoginMessage()
{
	const loginMessageLabel = document.getElementById("login-message");
	loginMessageLabel.innerHTML = "";
	loginMessageLabel.style.color = "black";
}

function displayLoginSuccess()
{
	const loginMessageLabel = document.getElementById("login-message");
	loginMessageLabel.innerHTML = "Login successful.";
	loginMessageLabel.style.color = "green";
}

function displayLoginError()
{
	const loginMessageLabel = document.getElementById("login-message");
	loginMessageLabel.innerHTML = "Invalid username/password.";
	loginMessageLabel.style.color = "red";
}

function clearRegisterMessage()
{
	const registerMessageLabel = document.getElementById("register-message");
	registerMessageLabel.innerHTML = "";
	registerMessageLabel.style.color = "black";
}

function displayRegisterSuccess()
{
	const registerMessageLabel = document.getElementById("register-message");
	registerMessageLabel.innerHTML = "Registration successful.";
	registerMessageLabel.style.color = "green";
}

function displayRegisterError()
{
	const registerMessageLabel = document.getElementById("register-message");
	registerMessageLabel.innerHTML = "Registration failed.";
	registerMessageLabel.style.color = "red";
}
