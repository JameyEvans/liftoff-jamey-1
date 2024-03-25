console.log("openLibraryCalls.js loaded.");

function selectBook(id, BookId)
{
    const updateUrl = '/BookClub/Update';
    $.ajax({
        url: `${updateUrl}?id=${id}&key=${BookId}`,
        type: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
        },
        data: JSON.stringify({ id: id, key: BookId }),
        success: function (response) {
            console.log('ID sent successfully');
            window.location.href = '/BookClub/Detail/' + id;
        },
        error: function (xhr, status, error) {
            console.error('Error sending ID:', error);
        }
    });
    return console.log(BookId);
}

document.addEventListener("DOMContentLoaded", () => {

    const searchResults = document.getElementById("searchResult");

    

    document.getElementById("submit").addEventListener("click", (event) => {

        event.preventDefault();
        const searchQuery = document.getElementById("searchQuery").value;

        console.log(searchQuery)

        async function getSearchResults(searchTerm) {

            searchResults.innerHTML = "<tr><th></th><th>Title</th><th>Author</th><th>Date Published</th></tr>"

            const fetchResult = await fetch(`https://openlibrary.org/search.json?q=${encodeURIComponent(searchTerm)}`);

            console.log(fetchResult);

            if (!fetchResult.ok) {
                return "Failed to fetch search from api";
            }
            const jsonData = await fetchResult.json();

            for (i = 0; i < 20; i++) {
                searchResults.innerHTML += `<tr><td><button type="button" onClick="selectBook('${jsonData.docs[i].isbn[0]}');">Add Book</button></td><td>${jsonData.docs[i].title}</td><td>${jsonData.docs[i].author_name}</td><td>${jsonData.docs[i].first_publish_year}</td></tr>`;
            }

        }

        getSearchResults(searchQuery);
        
    })
})