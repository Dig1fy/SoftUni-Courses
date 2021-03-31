import logo from './logo.svg';
import styles from './App.module.css';
import Header from './components/header/header'
import Aside from './components/aside/aside'
import Posts from './components/posts/posts'

const App = () => {
  return (
    <div className={styles.container}>
      <Header />
      <div>
        <Aside/>
        <Posts/>
      </div>
    </div>
  );
}

export default App;
