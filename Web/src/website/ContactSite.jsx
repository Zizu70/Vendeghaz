import styles from '../styles/ContactDesign.css';

function ContactSite() {
  return (
    <div className={styles['contactSite']}>
      <header>
        <h2>KAPCSOLAT</h2>
      </header>

      <main>
        <h3>Ha egyik kisvendégünket szeretnéd örökbe fogadni</h3>
        <h3>Ideiglenes befogadónk szeretnél lenni</h3>
        <h3>Munkánkat szeretnéd segíteni</h3>
        <h3>Önkénteskednél</h3>
        <h3>Vagy csak szimpatikus a munkánk ......</h3>        

        <br></br>

        <div className={styles['card']}>
          <h2>Vendégház Menedék Alapítvány</h2>
          <ul className={styles['info']}>
            <li>Email: info@vendeghazmenedek.hu</li>
            <li>Telefonszám: +36 40 111 2233</li>
            <li>Cím: 9999 Csendeszug, Menedék utca 1.</li>
          </ul>
        </div>

        <h3>Megtalálsz minket:</h3>
        <h3>hétfőtől - péntekig</h3>
        <h3>8:00 - 14:00</h3>
        <h3>szombatonként</h3>
        <h3>8:00 - 12:00</h3>        

      </main>

      <footer>
        <h2>Látogass el hozzánk! Szeretettel várunk</h2>
      </footer>
    </div>
  );
}

export default ContactSite;