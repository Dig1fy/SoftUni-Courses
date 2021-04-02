import React from "react";
import Post from "../post/post";
import styles from "./posts.module.css";

class Posts extends React.Component {
  constructor(props) {
    super(props);

    this.state = { origamis: [] };
  }

  getOrigamis = async () => {
    fetch(`http://localhost:9999/api/origami?length=${+this.props.length || 20}`)
      .then((x) => x.json())
      .then((data) => this.setState({ origamis: data }))
      .catch((err) => console.log(err));
    // this.setState({ origamis: origamis })
  };

  renderOrigamis() {
    const { origamis } = this.state;
    return origamis.map((origam, currentIndex) => {
      return <Post key={origam._id} index={currentIndex + 1} {...origam} />;
    });
  }

  componentDidMount() {
    this.getOrigamis();
  }

  render() {
    return (
      <div className={styles.posts}>
        {this.renderOrigamis()}
      </div>
    );
  }
}

export default Posts;
