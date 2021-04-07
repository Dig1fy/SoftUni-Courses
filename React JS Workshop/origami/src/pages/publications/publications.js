import React, { useState } from 'react'
import Title from '../../components/title/title'
import PageLayout from '../../components/layout/layout'
import styles from './publications.module.css'
import SubmitButton from '../../components/submitButton/submitButton'
import Posts from '../../components/posts/posts'
import getCookie from '../../helper-functions/getCookie'
// import UserContext from '../../Context'

const PublicationsPage = () => {
    const [post, setPost] = useState('')
    // const context = UserContext

    const submitHandler = (e) => {
        e.preventDefault();
        const cookieToken = getCookie('x-auth-token')
        // console.log(cookieToken)

        fetch('http://localhost:9999/api/origami', {
            method: "POST",
            body: JSON.stringify({ description: post }), //it's named "description" in our restAPI
            headers: {
                "Content-Type": "application/json",
                'Authorization': `${cookieToken}`
            }
        }).then(promise => promise.json())
            .then(dataa => console.log(dataa))
            .catch(err => console.log(err))

    }

    return (
        <PageLayout>
            <form onSubmit={(e) => submitHandler(e)}>
                <Title title="Share your thoughts" />
                <div className={styles.container}>
                    <textarea className={styles.textarea} onChange={e => setPost(e.target.value)}></textarea>
                    <div>
                        <SubmitButton buttonValue={"Submit"} onClickHandler={(e) => submitHandler(e)} />
                    </div>
                </div>
            </form>

            <Posts length={3} />
        </PageLayout>
    )
}

export default PublicationsPage