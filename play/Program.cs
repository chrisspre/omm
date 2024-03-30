using play;


var p = new Path(
    new Node("t0", "EntityType"),
    new Edge("Contains"), new Node("p0", "Property"), new Edge("Type"),
    new Node("t1", "PrimitiveType")
);
Console.WriteLine(p);

p = new Path(
   new Node("t0", "EntityType"),
   new Edge("Contains"), new Node("p0", "Property"), new Edge("Type"),
   new Node("t1", "ComplexType"),
   new Edge("Contains"), new Node("p1", "Property"), new Edge("Type"),
   new Node("t2", "PrimitiveType")
);
Console.WriteLine(p);

p = new Path(
    new Node("t0", "EntityType"),
    new Repetition(0..,
        [new Edge("Contains"), new Node("p", "Property"), new Edge("Type")],
        [new Node("t", "ComplexType")]),
    new Node("t2", "PrimitiveType")
);
Console.WriteLine(p);


