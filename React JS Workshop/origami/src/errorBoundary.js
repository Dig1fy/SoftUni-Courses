import React from "react";
import image from './images/404.png'
import styles from './errorBoundary.module.css'

class ErrorBoundary extends React.Component {
  constructor(props) {
    super(props);

    this.state = { isThereAnError: false };
  }

  static getDerivedStateFromError(error) {
    return { isThereAnError: true };
  }

  componentDidCatch(error, info) {
    console.log("New error occured in componentDidCatch:", error, info);
  }

  render() {
    if (this.state.isThereAnError) {
      return <div>
        <div className={styles.textContainer}>The page you're looking for is missing. Are you missing something? </div>;
        <div className={styles.image}>
          <img src={image} alt="" className={styles.image}></img>
        </div>
      </div>
    }
    return this.props.children;
  }
}

export default ErrorBoundary;
