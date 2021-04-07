import React from 'react'
import styles from './submitButton.module.css'

const SubmitButton = ({ buttonValue, onClickHandler = null }) => {

    return (
        <button type="submit" onClick = {onClickHandler} className={styles["submit-button"]}>{buttonValue}</button>
    )
}

export default SubmitButton