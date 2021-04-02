import React from 'react'
import styles from './submitButton.module.css'

const SubmitButton = ({buttonValue}) => {

    return (
        <button type="submit" className={styles["submit-button"]}>{buttonValue}</button>
    )
}

export default SubmitButton