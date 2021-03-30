import React from 'react'
import styles from './link.module.css'

const Link = ({reff, number, type}) => {
    
    return (
        <div className={styles[`${type}-list-item`]}>
            <a href={reff} className ={styles[`${type}-link`]}>
                {`Going to ${number}`}
            </a>
        </div>
    )
}

export default Link