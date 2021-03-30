import logo from './logo.svg';
import styles from './App.module.css';
import Header from './components/header/header'
import Aside from './components/aside/aside'

const App = () => {
  return (
    <div className={styles.container}>
      <Header />
      <div>
        <Aside/>
      </div>
    </div>
  );
}

export default App;
