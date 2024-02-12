console.log("openLibraryCalls.js loaded.");



document.addEventListener("DOMContentLoaded", () => {

    const searchResults = document.getElementById("searchResult");

    document.getElementById("submit").addEventListener("click", (event) => {

        event.preventDefault();
        const searchQuery = document.getElementById("searchQuery").value;

        console.log(searchQuery)

        async function getSearchResults(searchTerm) {

            searchResults.innerHTML = ''
            
            const fetchResult = await fetch(`https://openlibrary.org/search.json?q=${encodeURIComponent(searchTerm)}`);

            console.log(fetchResult);

            if (!fetchResult.ok) {
                return "Failed to fetch search from api";
            }
            const jsonData = await fetchResult.json();

            const doc = jsonData.docs;
            console.log(doc[0].title)

           

            for (i = 0; i < 20; i++) {
                searchResult.innerHTML += `<tr>${i + 1}</tr><tr>${doc[i].title}</tr><tr>${doc[i].author_name}</tr><tr>${doc[i].publish_year}</tr>`
            }

            searchResults.innerHTML = (doc) ? doc : "No results found."
        }
        

        getSearchResults(searchQuery);
    })
})