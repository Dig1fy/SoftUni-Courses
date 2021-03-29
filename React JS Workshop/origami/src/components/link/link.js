import React from 'react'
import styles from './link.module.css'

const Link = ({reff, number}) => {
    
    return (
        <div className={styles.listItem}>
            <a href={reff}>
                {`Going to ${number}`}
            </a>
        </div>
    )
}

export default Link