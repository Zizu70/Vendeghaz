import { useEffect, useState } from 'react';
import api from '../api/axios';

const Adoptions = () => {
  const [adoptions, setAdoptions] = useState([]);

  useEffect(() => {
    api.get('/adoption')
      .then(res => setAdoptions(res.data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div>
      <h2>Örökbefogadások</h2>

      <p>Egyedi, állat- és környezetbarát ajándékot keresel? Ajándékozz virtuális örökbefogadást, amivel mosolyt csalhatsz szeretteid arcára, megörvendeztetheted a vadasparki állatokat, és kímélheted a bolygót is!
      Az örökbefogadás összegével ráadásul kiválasztott állat jólétéhez is hozzájárulhatsz, hiszen a takarmányozásukra, az állatorvosi ellátásukra és a kifutóik rendszeres felújításara, a környezetgazdagításra fordítjuk azt.</p>
      <br></br>
      <p>Az örökbefogadók cserébe névre szóló „Zöld Oklevelet” kapnak, és egy évig büszkélkedhetnek a „Vadaspark Támogatószülő” titulussal, nevük pedig felkerül a Vadasparkban elhelyezett nevelőszülői táblára.Évente kétszer pedig egy különleges szülői értekezletet is rendezünk: a Nevelőszülők Napját, ahová minden örökbefogadót meghívunk, akik egy fő kísérőt is hozhatnak magukkal. Ezen a napon ingyen látogathatják meg kis/nagy védencüket, valamint megismerkedhetnek és beszélgethetnek gondozóikkal is.</p>
      <hr></hr>
      <p>Az örökbefogadás támodatói díja:</p>
      <br></br>
      <p>20.000 Ft/12 hónap</p>    
      <br></br>
      <p>Ha kiválasztottad a megfelelő „állati személyt”, írj egy e-mailt a orokbefogadas@vendeghaz.hu címre, és hamarosan felvesszük Veled a kapcsolatot!</p>
      <hr></hr>      
      <p>Örökbefogadás igényléshez kérjük töltse ki az adatlapot, melyet itt tud letölteni. A kitöltött igénylőlap leadható a  pénztárunknál, vagy e-mailen a orokbefogadas@vendeghaz.hu címen. Az örökbefogadás ára befizethető átutalással vagy személyesen pénztárunkban. A névre szóló örökbefogadást 10 munkanapon belül a megadott postacímre kiküldjük , vagy személyesen átvehető a Vadaspark pénztárában.</p>
      <hr></hr>
      <p>Az összeget az alábbi számlaszámunkra kérjük utalni: 99887766-55443322-11000000</p>
      <p>www.vendeghazvadaspark.hu  Támogathat minket adója 1%-val is: adószám:11223344-5-66 </p>

      <table className="table table-striped">
        <thead>
          <tr>
            <th>Állat neve</th>
            <th>Faja</th>
            <th>Neme</th>
            <th>Születési dátuma</th>
            <th>Örökbefogadó neve</th>
          </tr>
        </thead>
        <tbody>
          {adoptions.map(a => (
            <tr key={a.a_id}>
              <td>{a.g_name}</td>
              <td>{a.g_species}</td>
              <td>{a.g_gender}</td>
              <td>{new Date(a.g_birthdate).toLocaleDateString('hu-HU')}</td>
              <td>{a.u_name}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Adoptions;