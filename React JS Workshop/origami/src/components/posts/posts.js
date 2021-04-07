import React, { useCallback, useContext, useEffect, useMemo, useState } from "react";
import UserContext from "../../Context";
import Post from "../post/post";
import styles from "./posts.module.css";

const Posts = (props) => {
  const context = useContext(UserContext)
  const [origamis, setOrigamis] = useState(context.origamis || []);


  const getOrigamis = useCallback(async () => {
    fetch(`http://localhost:9999/api/origami?length=${+props.length || 20}`)
      .then((x) => x.json())
      .then((data) => setOrigamis(data))
      .catch((err) => console.log(err));
    // this.setState({ origamis: origamis })
  }, [props.length]);

  // const renderOrigamis = () => {
  //   return origamis.map((origam, currentIndex) => {
  //     return <Post key={origam._id} index={currentIndex + 1} {...origam} />;
  //   });
  // }

  const renderOrigamis = () => {
    console.log(origamis);
    return origamis.map((origam, index) => {
      return <Post key={origam._id} index={index + 1} {...origam} />;
    })
  }

  useEffect(() => {
    getOrigamis();
  }, [])

  return (
    <div className={styles.posts}>
      {renderOrigamis()}
    </div>
  );
}


export default Posts;
