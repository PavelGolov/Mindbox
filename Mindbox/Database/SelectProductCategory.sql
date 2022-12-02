SELECT p.Name, c.Name
FROM Product p
LEFT JOIN ProductCategory pc
ON p.Id = pc.ProductId
LEFT JOIN Category c
ON pc.CategoryId = c.Id
