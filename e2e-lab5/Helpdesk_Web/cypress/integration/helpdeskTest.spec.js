describe("Helpdesk e2e-tests", () => {
  it("IT-helpdesk form submit is working", () => {
    cy.visit("/");

    cy.get("#ITHelpdeskForm").as("Form");

    cy.get("@Form").children("select[name=type]").select("account");

    cy.get("@Form").children("input[name=product]").type("[TEST]");

    cy.get("@Form").children("input[name=name]").type("[TEST]");

    cy.get("@Form").children("input[name=phoneNumber]").type("[TEST]");

    cy.get("@Form").children("input[name=email]").type("TEST@TEST.com");

    cy.get("@Form")
      .children("textarea[name=description]")
      .type("[TEST]");

    cy.intercept("submit").as("postRequest");

    cy.get("@Form").children("button").click();

    cy.wait("@postRequest").should(({ response }) => {
      expect(response.statusCode).to.equal(200);
    });

    cy.get("@Form").children("p").contains("Helpdesk registered!");
  });

  it("Maintenance Helpdesk form submit is working", () => {
    cy.visit("/");

    cy.get("#MaintenanceHelpdeskForm").as("Form");

    cy.get("@Form").children("select[name=type]").select("entrance");

    cy.get("@Form").children("select[name=priority]").select("2");

    cy.get("@Form").children("input[name=name]").type("[TEST]");
    
    cy.get("@Form").children("input[name=phoneNumber]").type("[TEST]");
    
    cy.get("@Form").children("input[name=email]").type("khosro@666.com");
    
    cy.get("@Form").children("input[name=roomNumber]").type("1234");

    cy.get("@Form")
      .children("textarea[name=description]")
      .type("[TEST]");

    cy.intercept("submit").as("postRequest");

    cy.get("@Form").children("button").click();

    cy.wait("@postRequest").should(({ response }) => {
      expect(response.statusCode).to.equal(200);
    });

    cy.get("@Form").children("p").contains("Helpdesk registered!");
  });

  it("HR Helpdesk form submit is working", () => {
    cy.visit("/");

    cy.get("#HRHelpdeskForm").as("Form");

    cy.get("@Form").children("select[name=type]").select("employment");

    cy.get("@Form").children("input[name=name]").type("[TEST]");
    
    cy.get("@Form").children("input[name=employmentNumber]").type("1234");
    
    cy.get("@Form").children("input[name=phoneNumber]").type("[TEST]");
    
    cy.get("@Form").children("input[name=email]").type("khosro@666.com");
    
    cy.get("@Form").children("input[name=chief]").type("[TEST]");

    cy.get("@Form")
      .children("textarea[name=description]")
      .type("[TEST]");

    cy.intercept("submit").as("postRequest");

    cy.get("@Form").children("button").click();

    cy.wait("@postRequest").should(({ response }) => {
      expect(response.statusCode).to.equal(200);
    });

    cy.get("@Form").children("p").contains("Helpdesk registered!");
  });
});