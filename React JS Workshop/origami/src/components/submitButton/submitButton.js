import React from 'react'
import styles from './submitButton.module.css'

const SubmitButton = ({ buttonValue, onClickHandler }) => {

    return (
        <button type="submit" onClick={onClickHandler || null} className={styles["submit-button"]}>{buttonValue}</button>
    )
}

export default SubmitButton