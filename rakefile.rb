require 'albacore'

@output_path = File.expand_path(File.join(File.dirname(__FILE__), "build"))


desc "Build and test CheeseWiz"
task :default => [:assemblyinfo, :msbuild, :nunit]

desc "Build the CheeseWiz app"
Albacore::MSBuildTask.new(:msbuild) do |msb|
	msb.log_level = :verbose
	
	Dir.mkdir(@output_path) unless File.exists?(@output_path)
	
	msb.properties = {
		:configuration => :Release,
		:OutputPath => @output_path
	}
	msb.targets [:Clean, :Build]
	msb.solution = "src/CheeseWiz.sln"
end

desc "Run a sample assembly info generator"
Albacore::AssemblyInfoTask.new(:assemblyinfo) do |asm|
	asm.log_level = :verbose
	
	asm.version = "0.0.0.1"
	asm.company_name = "TrackAbout, Inc."
	asm.product_name = "CheeseWiz"
	asm.description = "Patch INF files for localized resources in Compact Framework CAB deployment"
	asm.copyright = "(C)2009 TrackAbout, Inc. All Rights Reserved."
	
	asm.output_file = "src/AssemblyInfo.cs"
end

desc "NUnit Test Runner Example"
Albacore::NUnitTestRunnerTask.new(:nunit) do |nunit|
	nunit.log_level = :verbose
	nunit.path_to_command = "Tools/NUnit-v2.5/nunit-console.exe"
	nunit.assemblies << File.join(@output_path, "CheeseWiz.Specs.dll")
end

