using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gallio.Model;
using Machine.Specifications.GallioAdapter.Services;
using Machine.Specifications.Model;
using Gallio.Common.Reflection;

namespace Machine.Specifications.GallioAdapter.Model
{
  public class MachineSpecificationTest : MachineGallioTest
  {
    private readonly Specification _specification;   

    public MachineSpecificationTest(Specification specification) : base(specification.Name, Reflector.Wrap(specification.FieldInfo))
    {
      this.Kind = TestKinds.Test;
      this.IsTestCase = true;
      _specification = specification;
    }

    public Result Execute()
    {
      MachineContextTest parent = this.Parent as MachineContextTest;
      if (parent == null) throw new Exception("Specification has non-Context parent???");
        
      return _specification.Verify();     
    }
  }
}
