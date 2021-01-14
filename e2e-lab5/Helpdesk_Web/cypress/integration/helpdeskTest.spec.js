describe('Helpdesk e2e-test', () => {
    it('IT-helpdesk form submit is working', () => {
        cy.visit('/');

        cy.get('#ITHelpdeskForm').get('#type').select('account');
        cy.get('#ITHelpdeskForm').get('#product').type('Docker port');
        cy.get('#ITHelpdeskForm').get('#name').type('Khosro');
        cy.get('#ITHelpdeskForm').get('#phoneNumber').type('0666');
        cy.get('#ITHelpdeskForm').get('#email').type('khosro@666.com');
        cy.get('#ITHelpdeskForm').get('#description').type('This shit suckes');

        cy.intercept('submit').as('postRequest')

        cy.get('#ITHelpdeskForm').get('#ITSubmit').click();

        cy.wait('@postRequest').should(({ response }) => {
            expect(response.statusCode).to.equal(200);
        })
    });
});