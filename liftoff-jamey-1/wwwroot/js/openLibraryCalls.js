console.log("openLibraryCalls.js loaded.");



document.addEventListener("DOMContentLoaded", () => {

    const searchResults = document.getElementById("searchResults");

    document.getElementById("submit").addEventListener("click", () => {
        
        const searchQuery = document.getElementById("searchQuery").innerText;
        
        async function getSearchResults(searchTerm) {
            
            const fetchResult = await fetch(`https://openlibrary.org/search.json?q=${searchTerm.toString().replace(" ", '+')}`);

            if (!fetchResult.ok) {
                return "Failed to fetch search from api";
            }
            const jsonData = await fetchResult.json();
            searchResults.innerHTML = jsonData.doc[0].title;
        }
        

        getSearchResults(searchQuery);
    })
})