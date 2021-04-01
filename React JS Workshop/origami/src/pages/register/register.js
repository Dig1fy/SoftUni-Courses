import React, { useState } from 'react'
import styles from './register.module.css'
import PageLayout from '../../components/layout/layout'

const RegisterPage = () => {
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')
    const [rePassword, setRePassword] = useState('')

    function handleSubmit(e) {
        e.preventDefault();
    }

    function changeUsername(event) {
        setUsername(event.target.value)
    }

    function changePassword(event) {
        setPassword(event.target.value)
    }

    function changeRePassword(event) {
        setRePassword(event.target.value)
    }

    return (
        <PageLayout>
            <div>TEST</div>
            <form className={styles.wrapper} onSubmit={(e) => handleSubmit(e)}>
                <h1>REGISTER TEST </h1>
                <input value={"zzzz"} value={username} onChange={(e) => changeUsername(e)} />

                <input type="password" value={password} onChange={(e) => changePassword(e)} />

                <input type="password" value={rePassword} onChange={(e) => changeRePassword(e)} />

                <button title="Register">Submit</button>
            </form>
        </PageLayout>
    )
}

export default RegisterPage