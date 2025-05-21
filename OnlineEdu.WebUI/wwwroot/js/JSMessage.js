document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("subscribeForm");

    form.addEventListener("submit", function (event) {
        event.preventDefault(); // sayfa yenilenmesin

        const email = document.getElementById("email").value.trim();
        const message = document.getElementById("message").value.trim();
        const name = document.getElementById("name").value.trim();
        const subject = document.getElementById("subject").value.trim();
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!email) {
            alert("E-posta boş olamaz!");
            return;
        }
        if (!emailRegex.test(email)) {
            alert("Geçerli bir e-posta adresi gir!");
            return;
        }
        if (!message) {
            alert("Mesaj boş olamaz!");
            return;
        }
        if (!name) {
            alert("İsim boş olamaz!");
            return;
        }
        if (!subject) {
            alert("Konu boş olamaz!");
            return;
        }

        Swal.fire({
            title: "Mesaj Başarıyla Gönderildi",
            text: "En Kısa Zamanda Geri Dönüş Alacaksınız!",
            icon: "success",
            confirmButtonText: "Tamam"
        }).then((result) => {
            if (result.isConfirmed) {
                form.submit();
            }
        });
    });
});
