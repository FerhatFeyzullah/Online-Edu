
function kontrolEtSubscriber()
{
    document.getElementById("subscribeForm").addEventListener("submit", function (event) {
        event.preventDefault(); // sayfa yenilenmesin

        const email = document.getElementById("email").value;
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (email === "") {
            alert("E-posta boş olamaz!");
            return;
        }
        if (!emailRegex.test(email)) {
            alert("Geçerli bir e-posta adresi gir!");
            return;
        }

        Swal.fire({
            title: "Abone Olma İşlemi Başarılı",
            text: "Teşekkürler!",
            icon: "success",
            confirmButtonText: "Tamam"
        }).then((result) => {
            if (result.isConfirmed) {
                // Swal onaylandı, formu gönder
                event.target.submit();
            }
        });
    });
}
