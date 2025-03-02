namespace lab{

    public class PSpec{
        public string spec;
        // WalkCallbakcType = we have a function
        // that takes a TreeNode and returns nothing (void).
        public delegate void WalkCallbackType( TreeNode n );
        public WalkCallbackType collectClassNames;
        public PSpec(string p, WalkCallbackType collectClassNames=null){
            this.spec=p;
            // nulling coelessient operator (if not null collectClassNames else defaultCollectClassNames)
            this.collectClassNames = collectClassNames ?? defaultCollectClassNames;
        }
        void defaultCollectClassNames( TreeNode n )
        {
            //FIXME: finish this
            foreach( TreeNode c in n.children)
            {
                c.collectClassNames();
            }
        }
    }
} //namespace