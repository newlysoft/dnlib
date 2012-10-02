﻿namespace dot10.DotNet {
	/// <summary>
	/// <see cref="ModuleDef"/> context
	/// </summary>
	public class ModuleContext {
		IAssemblyResolver assemblyResolver;
		IResolver resolver;

		/// <summary>
		/// Gets/sets the assembly resolver. This is never <c>null</c>.
		/// </summary>
		public IAssemblyResolver AssemblyResolver {
			get { return assemblyResolver; }
			set { assemblyResolver = value ?? NullAssemblyResolver.Instance; }
		}

		/// <summary>
		/// Gets/sets the resolver. This is never <c>null</c>.
		/// </summary>
		public IResolver Resolver {
			get { return resolver; }
			set { resolver = value ?? NullResolver.Instance; }
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		public ModuleContext()
			: this(null, null) {
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="assemblyResolver">Assembly resolver or <c>null</c></param>
		public ModuleContext(IAssemblyResolver assemblyResolver)
			: this(assemblyResolver, null) {
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="resolver">Type/method/field resolver or <c>null</c></param>
		public ModuleContext(IResolver resolver)
			: this(null, resolver) {
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="assemblyResolver">Assembly resolver or <c>null</c></param>
		/// <param name="resolver">Type/method/field resolver or <c>null</c></param>
		public ModuleContext(IAssemblyResolver assemblyResolver, IResolver resolver) {
			this.assemblyResolver = assemblyResolver;
			this.resolver = resolver;
			if (resolver == null && assemblyResolver != null)
				this.resolver = new Resolver(assemblyResolver);
			if (this.assemblyResolver == null)
				this.assemblyResolver = NullAssemblyResolver.Instance;
			if (this.resolver == null)
				this.resolver = NullResolver.Instance;
		}
	}
}