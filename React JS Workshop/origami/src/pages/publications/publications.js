import React, { useState } from 'react'
import Title from '../../components/title/title'
import PageLayout from '../../components/layout/layout'
import styles from './publications.module.css'
import SubmitButton from '../../components/submitButton/submitButton'
import Posts from '../../components/posts/posts'
import getCookie from '../../helper-functions/getCookie'
// import UserContext from '../../Context'

const PublicationsPage = () => {
    const [post, setTheFxxxingPost] = useState('')
    const [updatedOrigami, setUpdatedOrigami] = useState([])
    // const context = UserContext

    const handleSubmit = async (e) => {
        e.preventDefault()
        const cookieToken = getCookie('x-auth-token')
        // console.log(cookieToken)

        await fetch('http://localhost:9999/api/origami', {
            method: "POST",
            body: JSON.stringify({ description: post }), //it's named "description" in our restAPI
            headers: {
                "Content-Type": "application/json",
                'Authorization': `${cookieToken}`
            }
        })

        setTheFxxxingPost('')
        //It just has to adjust the array and trigger the componentDIdUpdate (which will render the new Post)
        setUpdatedOrigami(updatedOrigami.concat(1))
    }

    return (
        <PageLayout>
            <form onSubmit={(e) => handleSubmit(e)}>
                <Title title="Share your thoughts" />
                <div className={styles.container}>
                    <textarea className={styles.textarea} value={post} onChange={e => setTheFxxxingPost(e.target.value)} />
                    <div>
                        <SubmitButton buttonValue={"Submit"} />
                    </div>
                </div>
            </form>

            <Posts length={3} updatedOrigami={updatedOrigami} />
        </PageLayout>
    )
}

export default PublicationsPage