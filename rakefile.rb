require 'rubygems'
require 'albacore'

@output_path = File.expand_path(File.join(File.dirname(__FILE__), "build"))
@config = environment = ENV['config'] || "Release"

Albacore.configure do |config|
  config.log_level = :verbose
  config.msbuild.use :net35
  config.nunit.command = "Tools/NUnit-v2.5/nunit-console.exe"
end

desc "Build and test CheeseWiz"
task :default => [:assemblyinfo, :msbuild, :nunit]

desc "Build the CheeseWiz app"
msbuild do |msb|
	Dir.mkdir(@output_path) unless File.exists?(@output_path)
	
	msb.properties(
		:configuration => @config,
		:OutputPath => @output_path
	)
	msb.targets :Clean, :Build
	msb.solution = "src/CheeseWiz.sln"
end

desc "Run a sample assembly info generator"
assemblyinfo do |asm|
	asm.version = "0.0.0.1"
	asm.company_name = "TrackAbout, Inc."
	asm.product_name = "CheeseWiz"
	asm.description = "Patch INF files for localized resources in Compact Framework CAB deployment"
	asm.copyright = "(C)2009 TrackAbout, Inc. All Rights Reserved."
	
	asm.output_file = "src/AssemblyInfo.cs"
end

desc "NUnit Test Runner Example"
nunit do |nunit|
	nunit.assemblies File.join(@output_path, "CheeseWiz.Specs.dll")
end

