import React from 'react'
import styles from './link.module.css'

const Link = ({ reff, linkContent, type }) => {

    return (
        <div className={styles[`${type}-list-item`]}>
            <a href={reff} className={styles[`${type}-link`]}>
                {`${linkContent || "########"}`}
            </a>
        </div>
    )
}

export default Link