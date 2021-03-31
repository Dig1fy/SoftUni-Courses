import logo from './logo.svg';
import styles from './App.module.css';
import Header from './components/header/header'
import Aside from './components/aside/aside'
import Posts from './components/posts/posts'
import Footer from './components/footer/footer'

const App = () => {
  return (
    <div className={styles.container}>
      <Header />
      <div>
        <Aside/>
        <Posts/>
      </div>
      <Footer/>
    </div>
  );
}

export default App;
