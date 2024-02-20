console.log("openLibraryCalls.js loaded.");

function selectBook(key)
{
   return console.log(key)
}

document.addEventListener("DOMContentLoaded", () => {

    const searchResults = document.getElementById("searchResult");

    

    document.getElementById("submit").addEventListener("click", (event) => {

        event.preventDefault();
        const searchQuery = document.getElementById("searchQuery").value;

        console.log(searchQuery)

        async function getSearchResults(searchTerm) {

            searchResults.innerHTML = "<tr><th></th><th>Title</th><th>Author</th><th>Date Published</th></tr>"

            const fetchResult = await fetch(`https://openlibrary.org/search.json?q=${encodeURIComponent(searchTerm)}&limit="/title/author"`);

            console.log(fetchResult);

            if (!fetchResult.ok) {
                return "Failed to fetch search from api";
            }
            const jsonData = await fetchResult.json();

            for (i = 0; i < 20; i++) {
                searchResult.innerHTML += `<tr><td><button type="button" onClick="selectBook('${jsonData.docs[i].isbn[0]}');">Add Book</button></td><td>${jsonData.docs[i].title}</td><td>${jsonData.docs[i].author_name}</td><td>${jsonData.docs[i].first_publish_year}</td></tr>`;
            }

        }

        getSearchResults(searchQuery);
        
    })
})