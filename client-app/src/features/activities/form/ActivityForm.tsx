import { observer } from 'mobx-react-lite';
import { useEffect, useState } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { Button, Header, Segment } from "semantic-ui-react";
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import { v4 as uuid } from 'uuid';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import MyTextInput from '../../../app/common/form/MyTextInput';
import MyTextArea from '../../../app/common/form/MyTextArea';
import MySelectInput from '../../../app/common/form/MySelectInput';
import { categoryOptions } from '../../../app/common/options/categoryOptions';
import MyDateInput from '../../../app/common/form/MyDateInput';
import { ActivityFormValues } from '../../../app/models/activity';

export default observer(function ActivityForm() {
    const { activityStore } = useStore();
    const { createActivity, updateActivity, loadActivity, loadingInitial } = activityStore;
    const { id } = useParams();
    const navigate = useNavigate();

    const [activity, setActivity] = useState<ActivityFormValues>(new ActivityFormValues());

    const validationSchema = Yup.object({
        title: Yup.string().required('The event title is required'),
        category: Yup.string().required('The event category is required'),
        description: Yup.string().required(),
        date: Yup.string().required('Date is required').nullable(),
        venue: Yup.string().required(),
        city: Yup.string().required(),
    })

    useEffect(() => {
        if (id) loadActivity(id).then(activity => setActivity(new ActivityFormValues(activity)))
    }, [id, loadActivity])

    function handleFormSubmit(activity: ActivityFormValues) {
        if (!activity.id) {
            let newActivity = {
                ...activity,
                id: uuid()
            }
            createActivity(newActivity).then(() => navigate(`/activities/${newActivity.id}`))
        } else {
            updateActivity(activity).then(() => navigate(`/activities/${activity.id}`))
        }
    }

    if (loadingInitial) return <LoadingComponent content='Loading activity...' />

    return (
        <Segment clearing>
            <Header content='ΛΕΠΤΟΜΕΡΕΙΕΣ ΔΡΑΣΤΗΡΙΟΤΗΤΑΣ' sub color='teal' />
            <Formik
                enableReinitialize
                validationSchema={validationSchema}
                initialValues={activity}
                onSubmit={values =>  handleFormSubmit(values)}>
                {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                    <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                        <MyTextInput name='title' placeholder='Τίτλος' />
                        <MyTextArea rows={12} name='description' placeholder='Περιγραφή' />
                        <MySelectInput options={categoryOptions} name='category' placeholder='Κατηγορία' />
                        <MyDateInput name='date' placeholderText='Ημερομηνία' showTimeSelect timeCaption='time' dateFormat='MMMM d, yyyy h:mm aa' />

                        <Header content='ΛΕΠΤΟΜΕΡΕΙΕΣ ΤΟΠΟΘΕΣΙΑΣ' sub color='teal' />
                        <MyTextInput name='venue' placeholder='Χώρος εκδήλωσης' />
                        <MyTextInput name='city' placeholder='Πόλη' />
                        <Button
                            disabled={isSubmitting || !dirty || !isValid}
                            loading={isSubmitting}
                            floated='right'
                            color='teal'
                            type='submit'
                            content='Υποβολή' />
                        <Button as={Link} to='/activities' floated='right' type='button' content='Ακύρωση' />
                    </Form>
                )}
            </Formik>
        </Segment>
    )
})