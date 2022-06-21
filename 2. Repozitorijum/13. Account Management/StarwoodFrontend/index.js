function login()
{
	clearLoginMessage();

	const username = document.getElementById("login-username").value;
	const password = document.getElementById("login-password").value;

	const request = fetch
	(
		'http://localhost:5135/api/account/authenticate',
		{
			headers:
			{
				Authorization: "Basic " + btoa(username + ":" + password)
			}
		}
	);

	request.then
	(
		function callback(response)
		{
			if (response.ok)
			{
				displayLoginSuccess();

				sessionStorage.setItem("username", username);
				sessionStorage.setItem("password", password);

				window.location.replace("home-page.html");
			}
			else displayLoginError();
		}
	);
}

function register()
{
	clearRegisterMessage();

	const username = document.getElementById("register-username").value;
	const password = document.getElementById("register-password").value;
	const firstname = document.getElementById("register-firstname").value;
	const lastname = document.getElementById("register-lastname").value;

	const request = fetch
	(
		`http://localhost:5135/api/account/register?username=${username}&password=${password}&firstname=${firstname}&lastname=${lastname}`,
		{
			method: "POST"
		}
	);

	request.then
	(
		function callback(response)
		{
			if (response.ok) displayRegisterSuccess();
			else displayRegisterError();
		}
	);
}
