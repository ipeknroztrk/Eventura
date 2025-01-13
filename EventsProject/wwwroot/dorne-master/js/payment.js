function loadSavedCardModal() {
    fetch('/Payment/GetSavedCards') // API'den kayıtlı kartları alıyoruz
        .then(response => response.json())
        .then(savedCards => {
            let savedCardsHtml = '';
            if (savedCards.length === 0) {
                savedCardsHtml = '<p>Kayıtlı kart bulunmamaktadır.</p>';
            } else {
                savedCards.forEach(card => {
                    savedCardsHtml += `
                        <div class="card mb-3 card-preview">
                            <div class="card-body card-body-preview">
                                <div class="card-image">
                                    <img src="https://upload.wikimedia.org/wikipedia/commons/0/04/Mastercard-logo.png" class="card-logo" alt="Card Logo">
                                </div>
                                <div class="card-number">
                                    ${card.cardNumber.replace(/\d(?=\d{4})/g, "*")}
                                </div>
                                <div class="card-holder">
                                    ${card.cardHolderName}
                                </div>
                                <div class="expires">
                                    Expiry: ${card.expiryDate}
                                </div>
                                <button class="btn btn-primary" onclick="selectSavedCard(${card.savedCardId}, '${card.cardNumber}', '${card.cardHolderName}', '${card.expiryDate}', '${card.cvv || ''}')">
                                    Bu Kartla Ödeme Yap
                                </button>
                            </div>
                        </div>
                    `;
                });
            }
            document.getElementById('savedCardsList').innerHTML = savedCardsHtml;
            var modal = new bootstrap.Modal(document.getElementById('savedCardModal'));
            modal.show();
        })
        .catch(error => {
            console.error('Kayıtlı kartlar yüklenirken hata oluştu:', error);
        });
}

function updateCardPreview(cardDetails) {
    const cardPreviewElement = document.getElementById('cardPreview');
    if (cardPreviewElement && cardDetails) {
        cardPreviewElement.innerHTML = `
            <h3>${cardDetails.cardHolderName}</h3>
            <p>Card Number: ${cardDetails.cardNumber}</p>
            <p>Expiration Date: ${cardDetails.expiryDate}</p>
        `;
    }
}



function selectSavedCard(savedCardId, cardNumber, cardHolderName, expiryDate, cvv) {
    const form = document.querySelector('form');
    if (!form) {
        console.error("Form element bulunamadı.");
        return;
    }

    // Kart bilgilerini form alanlarına aktar
    const cardNumberInput = document.getElementById('cardNumber');
    const cardHolderNameInput = document.getElementById('cardHolderName');
    const expiryDateInput = document.getElementById('expiryDate');
    const cvvInput = document.getElementById('cvv');

    cardNumberInput.value = cardNumber;
    cardHolderNameInput.value = cardHolderName;
    expiryDateInput.value = expiryDate;

    // Kayıtlı kart ID'sini form'a ekle
    let existingSavedCardInput = document.getElementById('existingSavedCardId');
    if (!existingSavedCardInput) {
        existingSavedCardInput = document.createElement('input');
        existingSavedCardInput.type = 'hidden';
        existingSavedCardInput.id = 'existingSavedCardId';
        existingSavedCardInput.name = 'existingSavedCardId';
        form.appendChild(existingSavedCardInput);
    }
    existingSavedCardInput.value = savedCardId;

    if (cvv && cvvInput) {
        cvvInput.value = cvv;
    }

    // Kart önizlemesini güncelle
    const cardDetails = { cardHolderName, cardNumber, expiryDate }; // Burada kart detayları kullanılabilir.
    updateCardPreview(cardDetails);
}






// Örnek CVV getirme fonksiyonu
function getSavedCVVByCardId(savedCardId) {
    // Burada veritabanından veya başka bir kaynaktan CVV'yi çekebilirsiniz.
    const savedCVVs = {
        1: "123", // savedCardId: CVV
        2: "456",
        3: "789"
    };
    return savedCVVs[savedCardId] || null;
}


// (Existing code for formatting card number and expiry date remains unchanged)

// Ödeme formuna geri dön
function goBackToForm() {
    var modalBody = document.querySelector('#paymentModal .modal-body');
    modalBody.innerHTML = `
        <div id="paymentCardPreview">
            <div class="card-number" id="cardNumberPreview">** ** ** **</div>
            <div class="card-holder" id="cardHolderNamePreview">Kart Sahibinin Adı</div>
            <div class="expires">Expires: <span id="expiryDatePreview">MM/YY</span></div>
            <img src="https://upload.wikimedia.org/wikipedia/commons/0/04/Mastercard-logo.png" class="card-logo" alt="Card Logo">
        </div>
        <form method="post" action="${form.action}">
            <button type="submit" class="btn btn-success w-100 mt-3">Ödemeyi Tamamla</button>
        </form>
    `;
}