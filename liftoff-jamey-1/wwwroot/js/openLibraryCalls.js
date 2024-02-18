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

            for (let i = 0; i < 20; i++) {
                let coverUrl = "";
                if (Array.isArray(jsonData.docs[i].lccn) && jsonData.docs[i].lccn.length > 0) {
                    coverUrl = `https://covers.openlibrary.org/b/lccn/${jsonData.docs[i].lccn[0]}-S.jpg`;
                } else {
                    coverUrl = "";
                }
                let coverImageHTML = coverUrl ? `<img class="book-cover" src="${coverUrl}" alt="Book Cover">` : "<span>No Image Found</span>";
                searchResults.innerHTML += `<tr><td>${i + 1}</td><td>${jsonData.docs[i].title}</td><td>${jsonData.docs[i].author_name}</td><td>${jsonData.docs[i].first_publish_year}</td><td>${coverImageHTML}</td></tr>`;

                console.log("Cover URL:", coverUrl);
            }
            if (jsonData.docs.length === 0) {
                searchResults.innerHTML = "No results found.";
            }
            
        }


        getSearchResults(searchQuery);
    })
})




//searchResults.innerHTML = (doc) ? doc : "No results found.";

/*for (let i = 0; i < 20; i++) {
    let coverUrl = `https://covers.openlibrary.org/b/lccn/${jsonData.docs[i].lccn}-S.jpg`;
    let coverImageHTML = jsonData.docs[i].cover_i ? `<img class="book-cover" src="${coverUrl}" alt="Book Cover">` : "<span>No Image Found</span>";
    searchResults.innerHTML += `<tr><td>${i + 1}</td><td>${jsonData.docs[i].title}</td><td>${jsonData.docs[i].author_name}</td><td>${jsonData.docs[i].first_publish_year}</td><td>${coverImageHTML}</td></tr>`;

}*/

/*for (let i = 0; i < 20; i++) {
    let coverUrl = `https://covers.openlibrary.org/b/lccn/${jsonData.docs[i].lccn[0]}-S.jpg`;
    console.log("Cover URL:", coverUrl);
    let coverImageHTML = (jsonData.docs[i].cover_i !== null && jsonData.docs[i].cover_i !== 0) ? `<img class="book-cover" src="${coverUrl}" alt="Book Cover">` : "<span>No Image Found</span>";
    searchResults.innerHTML += `<tr><td>${i + 1}</td><td>${jsonData.docs[i].title}</td><td>${jsonData.docs[i].author_name}</td><td>${jsonData.docs[i].first_publish_year}</td><td>${coverImageHTML}</td></tr>`;

}*/