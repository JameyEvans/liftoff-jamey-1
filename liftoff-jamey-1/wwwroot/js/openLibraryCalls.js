console.log("openLibraryCalls.js loaded.");



document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("submit").addEventListener("click", () => {
        const searchResults = document.getElementById("searchResults");

        
        async function getSearchResults(searchTerm) {

            const fetchResult = await fetch(`https://openlibrary.org/search.json?q=${searchTerm.toString().replace(" ", '+')}`);

            if (!fetchResult.ok) {
                return "Failed to fetch search from api";
            }
            const jsonData = await fetchResult.json();
            searchResults.innerHTML = jsonData[0].title;
        }

        getSearchResults(document.getElementById("searchQuery"));
    })
})