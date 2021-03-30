import React from 'react'
import styles from './post.module.css'

const Post = () =>{
    return (
        <div className = {styles.post}>
            <img></img>
            <p className={styles.post-description}>
                afsafasfasfasfasfa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            </p>
            <div>
                <span>
                    <smal>Author:</smal>
                    Gosho
                </span>
            </div>
        </div>
    )
}

export default Post