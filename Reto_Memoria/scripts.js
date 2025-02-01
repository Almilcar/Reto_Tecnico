function flipCard(cardElement) {
    const card = $(cardElement);
    const front = card.find('.front');
    const back = card.find('.back');

    if (card.hasClass('flipped')) {
        return;
    }

    front.show();
    back.hide();
    card.addClass('flipped');
}