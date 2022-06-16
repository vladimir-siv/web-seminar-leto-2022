const movies = ['Harry Potter', 'The Pink Panther', 'Star Wars', 'Hobbit'];
let index = movies.length;

function nextMovie() {
    if (index === movies.length) index = 0;
    else ++index;
    return movies[index];
}

function enableButtons() {
    const app = document.getElementById("app");
    const buttons = app.getElementsByTagName("button");
    for (let button of buttons) {
        button.disabled = false;
    }
}

function disableButtons() {
    const app = document.getElementById("app");
    const buttons = app.getElementsByTagName("button");
    for (let button of buttons) {
        button.disabled = true;
    }
}

function searchMovie() {
    disableButtons();
    const start = Date.now();
    while (Date.now() - start < 7500) ;
    enableButtons();
    return nextMovie();
}

function searchMovieAsync() {
    disableButtons();
    return new Promise(resolve => {
        setTimeout(
            () => {
                enableButtons();
                resolve(nextMovie());
            }
        , 7500);
    });
}
