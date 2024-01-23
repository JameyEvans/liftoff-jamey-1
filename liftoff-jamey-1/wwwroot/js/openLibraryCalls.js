

document.addEventListener("click", () => {
    const searchResults = document.getElementById("searchResults");

    async function getSearchResults(searchTerm) {
        const fetchResult = await fetch(`https://openlibrary.org/search.json?q=${searchTerm}`);

        if (!fetchResult.ok) {
            return "Failed to fetch search from api";
        }
        const jsonData = await fetchResult.json();
        clientSearch.innerHTML = jsonData[0].title
    }

    getSearchResults();



})