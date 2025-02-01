let flippedCards = []; // Almacena las cartas volteadas
let lockBoard = false; // Evita que el usuario haga clic mientras se voltean las cartas

function flipCard(cardElement) {
    if (lockBoard || cardElement.classList.contains('flipped')) {
        return; // No hacer nada si el tablero está bloqueado o la carta ya está volteada
    }

    const card = $(cardElement);
    const front = card.find('.front');
    const back = card.find('.back');

    front.show();
    back.hide();
    card.addClass('flipped');

    flippedCards.push(cardElement);

    if (flippedCards.length === 2) {
        checkForMatch();
    }
}

function checkForMatch() {
    const [firstCard, secondCard] = flippedCards;

    const firstImage = $(firstCard).find('.front').attr('src');
    const secondImage = $(secondCard).find('.front').attr('src');

    if (firstImage === secondImage) {
        // Las cartas coinciden
        flippedCards = [];
    } else {
        // Las cartas no coinciden
        lockBoard = true;
        setTimeout(() => {
            $(firstCard).removeClass('flipped').find('.front').hide().end().find('.back').show();
            $(secondCard).removeClass('flipped').find('.front').hide().end().find('.back').show();
            flippedCards = [];
            lockBoard = false;
        }, 1000); // Retraso de 1 segundo antes de voltear las cartas
    }
}