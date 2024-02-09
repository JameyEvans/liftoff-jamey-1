console.log("openLibraryCalls.js loaded.");



document.addEventListener("DOMContentLoaded", () => {

    const searchResults = document.getElementById("searchResult");

    document.getElementById("submit").addEventListener("click", (event) => {
        
        event.preventDefault();
        const searchQuery = document.getElementById("searchQuery").value;

        console.log(searchQuery)

        async function getSearchResults(searchTerm) {
        
            const fetchResult = await fetch(`https://openlibrary.org/search.json?q=${encodeURIComponent(searchTerm)}`);

            console.log(fetchResult);

            if (!fetchResult.ok) {
                return "Failed to fetch search from api";
            }
            const jsonData = await fetchResult.json();


            const text = jsonData.docs[0].first_sentence[0];

            
         

            searchResults.innerHTML = (text) ? text : "No results found.";  
        }
        

        getSearchResults(searchQuery);
    })
})