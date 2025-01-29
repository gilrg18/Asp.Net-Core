document.querySelector("#load-friends-button").addEventListener("click",
    async function () {
        let response = await fetch("friends", { method: "GET" })
        let responseBody = await response.text();
        document.querySelector("#list").innerHTML = responseBody;
    })