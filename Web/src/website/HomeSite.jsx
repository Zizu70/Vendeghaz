import 'bootstrap/dist/css/bootstrap.min.css';

import image0 from '../assets/logo.png';

import {Carousel} from 'react-bootstrap';
import image1 from '../assets/hit1.jpg';
import image2 from '../assets/hit2.jpg';
import image3 from '../assets/hit3.jpg';
import image4 from '../assets/hit4.jpg';
import image5 from '../assets/hit5.jpg';
import image6 from '../assets/hit6.jpg';
import image7 from '../assets/hit7.jpg';
import image8 from '../assets/hit8.jpg';
import image9 from '../assets/hit9.jpg';
import image10 from '../assets/hit10.jpg';
import image11 from '../assets/hit11.jpg';
import image12 from '../assets/hit12.jpg';

import image13 from '../assets/hit13.jpg';


import design from '../design/HomeDesign.css';
import BasisDesign from '../design/BasisDesign.css';


function HomeSite() {

  return (
    <div className={design['homeSite']}>
        <header className={design['homeSiteHeader']}>
            <div className={design['container']}>
                <h2>Hisszük, hogy vendégeink nálunk egy örök barátra találnak!</h2>
                <img className={BasisDesign['card-img-top']} src={image0} alt="Logo" />
                <p>blablablablablaba</p>
            </div>
        </header>

        <main>
            <Carousel className={design['carousel-card']}>
                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image1}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item>    

                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image2}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item> 

                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image3}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item> 

                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image4}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item>
                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image5}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item>    

                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image6}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item> 

                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image7}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item> 

                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image8}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item>

                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image9}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item>    

                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image10}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item> 

                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image11}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item> 

                <Carousel.Item>
                    <div className={design['carousel-image-container']}>
                        <img className={design['carousel-image']}
                        src={image12}
                        alt="A"/>
                    </div>
                <Carousel.Caption className={design['caption-text']}>
                    <h2><strong>A</strong></h2>
                </Carousel.Caption>
                </Carousel.Item>
            </Carousel>    
        </main>

        <section className="py-5">
          <br />
          <div className={design['container']}>
            <h2>B</h2>
            <p>BB</p>
            <img className={BasisDesign['card-img-top']} src={image13} alt="Fourth slide" />
          </div>
        </section>
 
      <footer>
        <div className={BasisDesign.center}> {/* Új div a gomb középre igazításához */}
          <button className="btn btn-secondary" type="button"  onClick={() => window.scrollTo(0, 0)}>Ugrás a lap tetejére</button>
        </div>
      </footer>
      <br />
    </div>
  );
}
//<img src={missionImage} alt="Mission" className="img-fluid" />
export default HomeSite;