describe("news pages", () => {
    it("should visit the news page", () => {
        cy.visit("http://localhost:5080/news");
    });

    it("can select a news article", () => {
        cy.visit("http://localhost:5080/news");
        cy.get(".news-card").first().click();
        cy.url().should('match', /news\/\d{4}-\d{2}-\d{2}-\s*/);
    });

    it("can select more news from a news article", () => {
        cy.visit("http://localhost:5080/news");
        cy.get(".news-card").first().click();
        cy.get(".news-article-details-column a h6").first().click();       
    })
});