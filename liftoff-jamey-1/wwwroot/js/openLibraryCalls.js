console.log("openLibraryCalls.js loaded.");



document.addEventListener("DOMContentLoaded", () => {

    const searchResults = document.getElementById("searchResult");

    document.getElementById("submit").addEventListener("click", (event) => {

        event.preventDefault();
        const searchQuery = document.getElementById("searchQuery").value;

        console.log(searchQuery)

        async function getSearchResults(searchTerm) {

            searchResults.innerHTML = "<tr><th>Number</th><th>Title</th><th>Author</th><th>Date Published</th><th>Book Cover Image</th></tr >"

            const fetchResult = await fetch(`https://openlibrary.org/search.json?q=${encodeURIComponent(searchTerm)}`);

            console.log(fetchResult);

            if (!fetchResult.ok) {
                return "Failed to fetch search from api";
            }
            const jsonData = await fetchResult.json();

            for (i = 1; i < 21; i++) {
                let coverUrl = `https://covers.openlibrary.org/b/oclc/${jsonData.docs[i].oclc}.jpg`;
                searchResults.innerHTML += `<tr><td>${[i]}</td><td>${jsonData.docs[i].title}</td><td>${jsonData.docs[i].author_name}</td><td>${jsonData.docs[i].first_publish_year}</td><td><img class="book-cover" src="${coverUrl}"></td></tr>`;
            }
            
                searchResults.innerHTML = (doc) ? doc : "No results found.";
        }


        getSearchResults(searchQuery);
    })
})