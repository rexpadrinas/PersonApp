import Button from 'react-bootstrap/Button'
import { Container } from 'react-bootstrap'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Table from 'react-bootstrap/Table';
import React, { useEffect, useState } from 'react'
import Pagination from 'react-bootstrap/Pagination';

function Person() {

    const [data, empdatachange] = useState([]);

    useEffect(()=>{
       fetch("https://my-json-server.typicode.com/m4ur1c1o86/codetest/persons").then((res) => {
        return res.json();
       }).then((resp) => {
        empdatachange(resp);
       }).catch((err)=>{
        console.log(err.message);
       })
    }, [])

  return (
    <>
      <div className='container-bg'>

        <Row>
        <Col md={{ span: 8, offset: 2 }}>

                      <table class="table table-hover" id='tbl-persons'>
                          <thead>
                              <tr className='bg-primary'>
                                  <th scope="col">#</th>
                                  <th scope="col">Name</th>
                                  <th scope="col">Age</th>
                                  <th scope="col">PersonTypeID</th>
                                  <th scope="col">Action</th>
                              </tr>
                          </thead>
                          <tbody>
                            {
                                data.map((item, index) => {
                                    return(
                                        <tr key={index}>
                                            <td>{item.ID}</td>
                                            <td>{item.Name}</td>
                                            <td>{item.Age}</td>
                                            <td>{item.PersonTypeID == 1 ? "Student" : "Teacher"}</td>
                                            <td>Edit/Delete</td>
                                        </tr>

                                    )
                                })
                            }
                          </tbody>
                      </table>

            </Col>
        </Row>
      </div>
    </>
  )
}

export default Person
