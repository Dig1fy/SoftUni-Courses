import React from 'react'
import styles from './input.module.css'

const Input = ({ labelContent, id, value, onChange, type }) => {

    return (
        <div className={styles.container}>
            <div>
                <label htmlFor={id}>{labelContent}: </label>
            </div>
            <div>
                <input autoComplete={id} className={styles.input} id={id} value={value} onChange={onChange} type={type || "text"} />
            </div>
        </div>
    )
}

export default Input