console.log("apiExample.js loaded");

document.addEventListener("DOMContentLoaded", () => {
    const clientJoke = document.getElementById("clientJoke");

    async function getJoke() {
        const fetchResult = await fetch("https://api.api-ninjas.com/v1/jokes?limit=1", {
            headers: {
                "X-Api-Key": "lYTJTp1w73+rvbmqdnL7eA==XBk9tavB5cphQTbv"
        }
        });
        if (!fetchResult.ok) {
            return "Failed to fetch joke from api";
        }
        const jsonData = await fetchResult.json();
        clientJoke.innerHTML = jsonData[0].joke;
    }

    getJoke();

    

})

